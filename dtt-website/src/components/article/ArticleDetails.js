import React from 'react';
import { Link } from 'react-router-dom';
import { formatDate } from '../Helper';

class Article extends React.Component {
    constructor(props) {
        super (props);
        this.state = { 
            title: '',
            description: '',
            publishDate: ''
        };
    }

    componentDidMount() {
        const { match: { params } } = this.props;

        // Calls the API to get the wanted artcile by ID
        fetch(`https://localhost:5001/api/article/${params.id}`)
        .then(response => response.json())
        .then((data) => { 
            this.setState({
                title: data.title,
                description: data.description,
                publishDate: formatDate(data.publishDate,'numeric','long','2-digit',false)
            })
        })
        .catch(
            error => console.log(error)
        );
    }

    render(){
        const {title, description, publishDate} = this.state;
           
        return (
            <div>
                <h1>{title}</h1>
                <p>{description}</p>
                <p className="publishdate">PUBLISHED ON {publishDate.toUpperCase()}</p>
                <Link to = "/">
                    <p> Return to Homepage </p> 
                </Link> 
            </div>
        )
    }
}

export default Article
