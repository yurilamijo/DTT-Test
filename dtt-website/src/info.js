import React from 'react';
import { Link } from 'react-router-dom';

class Info extends React.Component {
    constructor(props) {
        super (props);
        this.state = { article: []};
    }

    componentDidMount() {
        const { match: { params } } = this.props;

        fetch(`https://localhost:5001/api/article/${params.id}`)
        .then(response => response.json())
        .then((data) => this.setState({ article: data }))
        .catch(
            error => console.log(error)
        );
    }

    render(){
        const {title, description, publishDate } = this.state.article;

        // const dateTimeFormat = new Intl.DateTimeFormat('en', { year: 'numeric', month: 'long', day: '2-digit' }); 
        // const [{value:month},, {value:day}] = dateTimeFormat.formatToParts(new Date(publishDate));
        
        return (
            <div>
                <h1>{title}</h1>
                <p>{description}</p>
                <p>{publishDate}</p>
                <Link to = "/">
                    <p> Return to Homepage </p> 
                </Link> 
            </div>
        )
    }
}

export default Info