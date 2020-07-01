import React from 'react';
import { withRouter } from 'react-router-dom';
import CustomInput from '../CustomeInput';
import { formatDate, getToken, getUserRole } from '../../Helper';
import '../../css/Form.css'

class ArticleForm extends React.Component {
    constructor(props) {
        super (props);
        this.state = {
            title: '',
            summary: '',
            description: '',
            publishDate: '',
        };

        this.handleChange = this.handleChange.bind(this);
        this.submitArticle = this.submitArticle.bind(this);
        this.deleteArticle = this.deleteArticle.bind(this);
    }

    componentDidMount() {
        const { match: { params } } = this.props;
        // Calls the API to get the selected article by ID
        // Will only be called if there was a ID als parameter
        if (params.id) {
            fetch(`https://localhost:5001/api/article/${params.id}`, {
                method: 'GET',
                headers: { 
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${getToken()}`
                },
            })
            .then(response => response.json())
            .then((data) => {
                this.setState({
                    id: data.id,
                    title: data.title,
                    summary: data.summary,
                    description: data.description,
                    publishDate: formatDate(data.publishDate,'numeric','2-digit','2-digit',true)
                })
            })
            .catch(
                error => console.log(error)
            );
        }
    }

    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.name;
        // Sets the value of the input by name if value gets changed
        this.setState({ [name]: value });
    }

    submitArticle(event) {
        event.preventDefault();
        const { match: { params } } = this.props;
        const callMethod = params.id ? 'PUT' : 'POST';
        let str = 'https://localhost:5001/api/article';
        // If method is PUT the call will be converted to a PUT call
        if (callMethod == 'PUT') str += `/${params.id}`;
        // API call that can be a POST or a PUT call
        fetch(str, {
            method: callMethod,
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${getToken()}`
            },
            body: JSON.stringify(this.state),
        }).then(
            // Redirects you to the admin page
            () => this.props.history.push('/admin')
        );
    }

    deleteArticle(event) {
        event.preventDefault();
        const { match: { params } } = this.props;
        // API call that deletes the selected article by ID
        fetch('https://localhost:5001/api/article/' + params.id,{
            method: 'DELETE',
            headers: { 
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${getToken()}`
            }
        }).then(
            // Redirects you to the admin page
            () => this.props.history.push('/admin')
        )
    }

    render() {
        const {title, summary, description, publishDate} = this.state;
        const { match: { params } } = this.props;

        let pageTitle, deleteLink;
        if (params.id) {
            pageTitle = "Edit"
            deleteLink = <a href="/admin" onClick={this.deleteArticle}>Delete This Article</a>
        } else {
            pageTitle = "Add"
            deleteLink = null
        }

        return (
            <div className="article-form">
                <h1>{pageTitle} Article</h1>
                <form className="form" onSubmit={this.submitArticle}>
                    <CustomInput lableName="Article Title" inputName="title" value={title} inputType={"text"} handleChange={this.handleChange}/>
                    <CustomInput lableName="Article Summary" inputName="summary" value={summary} inputType={"textarea"} handleChange={this.handleChange}/>
                    <CustomInput lableName="Article Content" inputName="description" value={description} inputType={"textarea"} handleChange={this.handleChange}/>
                    <CustomInput lableName="Publication Date" inputName="publishDate" value={publishDate} inputType={"date"} handleChange={this.handleChange}/>
                    <div className="form-footer">
                        <button type="submit">Save Changes</button>
                        <button>Cancel</button>
                    </div>
                </form>
                {getUserRole() == "Admin" ? deleteLink : null}
            </div>  
        )
    }
}

export default withRouter(ArticleForm);
