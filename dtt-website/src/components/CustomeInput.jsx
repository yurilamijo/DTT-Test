import React from 'react';

class CustomInput extends React.Component {
    render() {
        const {lableName, inputName, value, placeholder, inputType, handleChange} = this.props;

        let valueClass = value ? "has-value" : "";
        let input;
        // Change the input type
        if(inputType == "textarea") {
            input = <textarea className={`form-input ${valueClass}`} 
                name={inputName}  
                type={inputType} 
                placeholder={placeholder} 
                value={value} 
                required 
                onChange={handleChange}
            ></textarea>
        } else {
            input = <input className={`form-input ${valueClass}`} 
                name={inputName} 
                type={inputType} 
                placeholder={placeholder } 
                value={value} 
                required 
                onChange={handleChange}
            />
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