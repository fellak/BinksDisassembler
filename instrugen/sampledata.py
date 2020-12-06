def get_sample_data():
    props = {}
    props['opcodes'] = []

    props['opcodes'].append({})
    props['opcodes'][0]['value'] = '0xfc'
    props['opcodes'][0]['size'] = 6
    props['opcodes'][0]['offset'] = 15 # optional

    props['opcodes'].append({})
    props['opcodes'][1]['value'] = '0xfc'
    props['opcodes'][1]['size'] = 6
    props['opcodes'][1]['offset'] = 15 # optional


    props['instruction'] = {}
    props['instruction']['name'] = 'l.ld'
    props['instruction']['formatString'] = 'D,I(A)' # optional
    props['instruction']['arguments'] = []

    # optional
    if (True):
        props['instruction']['arguments'].append({})
        props['instruction']['arguments'][0]['name'] = 'D'
        props['instruction']['arguments'][0]['size'] = '5'
        props['instruction']['arguments'][0]['offset'] = '6' # optional
        props['instruction']['arguments'][0]['strategy'] = 'RStrategy' # optional

        props['instruction']['arguments'].append({})
        props['instruction']['arguments'][1]['name'] = 'D'
        props['instruction']['arguments'][1]['size'] = '5'
        props['instruction']['arguments'][1]['offset'] = '6' # optional
        props['instruction']['arguments'][1]['strategy'] = 'RStrategy' # optional

    return props
