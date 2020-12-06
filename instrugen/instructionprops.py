class InstructionProps:
    def __init__(self):
        self.props = {}
        self.props['opcodes'] = []
        self.props['instruction'] = {}
        self.props['instruction']['formatString'] = ''
        self.props['instruction']['arguments'] = []

    def get_props(self):
        return self.props

    def set_file_name(self, file_name):
        file_name_parts = list(map(lambda file_name_part: file_name_part.capitalize(), file_name.split('.')))
        file_name_parts.pop(0)
        self.file_name = ''.join(file_name_parts)
        self.props['class_name'] = self.file_name

    def get_file_name(self):
        return self.file_name

    def set_target_path(self, target_path):
        self.target_path = target_path

    def get_target_path(self):
        return self.target_path

    def new_opcode(self, value, size):
        self.props['opcodes'].append({})
        i = len(self.props['opcodes']) - 1
        self.props['opcodes'][i]['value'] = value
        self.props['opcodes'][i]['size'] = size

    def add_to_last_opcode(self, key, value):
        i = len(self.props['opcodes']) - 1
        self.props['opcodes'][i][key] = value

    def set_instruction_props(self, key, value):
        self.props['instruction'][key] = value

    def append_instruction_format_string(self, value):
        if (len(self.props['instruction']['formatString']) > 0):
            self.props['instruction']['formatString'] = ','.join([self.props['instruction']['formatString'], value])
        else:
            self.props['instruction']['formatString'] = value

    def new_argument(self, name, size):
        self.props['instruction']['arguments'].append({})
        i = len(self.props['instruction']['arguments']) - 1
        self.props['instruction']['arguments'][i]['name'] = name
        self.props['instruction']['arguments'][i]['size'] = size
        self.props['instruction']['arguments'][i]['strategy'] = 'UnimplementedStrategy'

    def add_to_last_argument(self, key, value):
        i = len(self.props['instruction']['arguments']) - 1
        self.props['instruction']['arguments'][i][key] = value
