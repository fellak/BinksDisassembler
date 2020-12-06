import pandas as pd
import xlrd

def process_merged_cells(df, sheet):
    for crange in sheet.merged_cells:
        rlo, rhi, clo, chi = crange
        val = sheet.cell_value(rlo, clo)
        size = chi - clo
        df.iloc[rlo, clo] = f"[{size}]{val}"
    return df

def parse_instructions_excel(i_path):
    excel_file = pd.ExcelFile(xlrd.open_workbook(i_path), engine='xlrd')
    sheet_2 = excel_file.book.sheet_by_index(2)
    df = excel_file.parse(2, header=None)

    return process_merged_cells(df, sheet_2)
