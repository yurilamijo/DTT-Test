import React from 'react';
import CustomInput from './CustomeInput';
import '../css/Form.css';

class LoginMenu extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: ''
        }

        this.handleChange = this.handleChange.bind(this);
        this.login = this.login.bind(this);
    }


    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        // Sets the value of the input by name if value gets changed
        this.setState({ [name]: value });
    }

    login(event) {
        event.preventDefault();
        const {username, password} = this.state;

        fetch('https://localhost:5001/api/auth/',{
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify({username, password})
        }).then(this.handleResponse)
        .then( user => {
            localStorage.setItem('user', JSON.stringify(user));
            // Redirects you to the admin page
            this.props.history.push('/admin')
        })
    }

    handleResponse(response) {
        return response.text().then(text => {
            const data = text && JSON.parse(text)
            if(!response.ok) {
                const error = (data && data.message) || response.statusText;
                return Promise.reject(error);
            }
            return data;
        });
    }

    render() {
        return(
            <div className="login-menu">
                <form className="form login" onSubmit={this.login}>
                    <CustomInput lableName="Username" inputName="username" inputType={"text"} handleChange={this.handleChange}/>
                    <CustomInput lableName="Password" inputName="password" inputType={"password"} handleChange={this.handleChange}/>
                   <div className="form-footer">
                       <button type="submit">Login</button>
                    </div>
                </form>
            </div>  
        )
    }
}

export default LoginMenu;