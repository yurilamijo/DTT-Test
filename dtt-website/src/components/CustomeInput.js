import React from 'react';

class CustomInput extends React.Component {
    render() {
        const {lableName, inputName, value, inputType, handleChange} = this.props;

        let input;
        if(inputType == "textarea") {
            input = <textarea className="form-input" name={inputName}  type={inputType} value={value} required onChange={handleChange}></textarea>
        } else {
            input = <input className="form-input" name={inputName} type={inputType} value={value} required onChange={handleChange}/>
        }

        return(
            <label>
                <p>{lableName}</p>
                {input}
            </label>
        )
    }
}

export default CustomInput;