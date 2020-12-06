from jinja2 import Environment, FileSystemLoader
from sampledata import get_sample_data
from xlsxparser import parse_instructions_excel
from instructionprops import InstructionProps
import pandas as pd
import re
import os

def render_instruction_class_to_file(instruction_props, ouput_folder):
    if not os.path.exists(ouput_folder):
        os.makedirs(ouput_folder)

    with open(f'{ouput_folder}/{instruction_props.get_file_name()}.cs', "w") as target_file:
        target_file.write(template.render(instruction_props.get_props()))

def loop_instructions_dataframe(df, out_path):
    for row in range(df.shape[0]):
        if (row < 2):
            continue

        instruction_props = InstructionProps()

        if (df.iat[row, 0] == 'ORBIS32/64'):
            instruction_props.set_file_name(df.iat[row, 1])
            instruction_props.set_target_path('Orbis.Generated')
        else:
            break # TODO: other families 

        instruction_props.set_instruction_props('name', df.iat[row, 1])

        for col in range(2, df.shape[1]):
            cell_data = df.iat[row,col]
            if pd.isna(cell_data):
                continue
            
            # Get size if cell was part of merged cells
            cell_size = re.findall(r"\[[0-9]*\]", cell_data)
            if (len(cell_size)):
                cell_size = re.search("[0-9]+", cell_size[0])
                size_match = re.search(r"\[[0-9]*\]", cell_data)
                cell_data = cell_data[:size_match.start()] + cell_data[size_match.end():]
                cell_size = cell_size.group(0)
            else:
                cell_size = 1 

            # Determine if parsing opcode
            is_op = re.search("^0x", cell_data)
            if is_op:
                instruction_props.new_opcode(cell_data, cell_size)
                opcode_offset = col - 2
                if (opcode_offset != 0):
                    instruction_props.add_to_last_opcode('offset', opcode_offset)
            elif (cell_data != ''):
                instruction_props.append_instruction_format_string(cell_data)
                
                instruction_props.new_argument(cell_data, cell_size)
                argument_offset = col - 2
                if (argument_offset != 0):
                    instruction_props.add_to_last_argument('offset', argument_offset)

        ouput_folder = f'{out_path}{instruction_props.get_target_path()}'
        render_instruction_class_to_file(instruction_props, ouput_folder)


env = Environment(
    loader=FileSystemLoader("templates")
)

template = env.get_template('instruction-factory.csjinja')

df = parse_instructions_excel('../docs/instructions.xlsx')

loop_instructions_dataframe(df, '../BinksDisassembler/Disassembler/Instructions/')
