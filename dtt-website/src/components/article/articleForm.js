import React from 'react';
import {withRouter} from 'react-router-dom';
import '../../css/form.css'

class ArticleForm extends React.Component {
    constructor(props) {
        super (props);
        this.state = {
            title: '',
            summary: '',
            description: '',
            publishDate: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.submitArticle = this.submitArticle.bind(this);
        this.deleteArticle = this.deleteArticle.bind(this);
    }

    componentDidMount() {
        // API call get data
        const { match: { params } } = this.props;
        if (params.id) {
            fetch(`https://localhost:5001/api/article/${params.id}`)
            .then(response => response.json())
            .then((data) => this.setState(data))
            .catch(
                error => console.log(error)
            );
        }
    }

    handleChange(event) {   
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({ [name]: value });
    }

    submitArticle(event) {
        event.preventDefault();
        const { match: { params } } = this.props;
        
        // const [day, month, year] = this.state.publishDate.split();
        // const serverDate = `${year}-${month}-${day}`;
        const callMethod = params.id ? 'PUT' : 'POST';
        let str = 'https://localhost:5001/api/article';
        if (callMethod == 'PUT') str += '/' + params.id

        fetch(str, {
            method: callMethod,
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.state),
        }).then(
            () => this.props.history.push('/admin')
        );
    }

    deleteArticle(event) {
        event.preventDefault();
        const { match: { params } } = this.props;

        fetch('https://localhost:5001/api/article/' + params.id,{
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' }
        }).then(
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
                <form className="form-article" onSubmit={this.submitArticle}>
                    <label>
                        <p>Article Title</p>
                        <input className="form-input" name="title" type="text" value={title} required onChange={this.handleChange}/>
                    </label>
                    <label>
                        <p>Article Summary</p>
                        <textarea className="form-input" name="summary" type="text" value={summary} required onChange={this.handleChange}></textarea>
                    </label>
                    <label>
                        <p>Article Content</p>
                        <textarea className="form-input" name="description" type="text" value={description} required onChange={this.handleChange}></textarea>
                    </label>
                    <label>
                        <p>Publication Date</p>
                        <input className="form-input" name="publishDate" type="text" value={publishDate} required onChange={this.handleChange}/>
                    </label>
                    <div className="form-footer">
                        <button type="submit">Save Changes</button>
                        <button>Cancel</button>
                    </div>
                </form>
                {deleteLink}
            </div>  
        )
    }
}

export default withRouter(ArticleForm);