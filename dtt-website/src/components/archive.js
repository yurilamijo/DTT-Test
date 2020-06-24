import React from 'react';
import ArticleBlock from './article/ArticleBlock';
import { Link } from 'react-router-dom';

class Archive extends React.Component {
    constructor(props) {
        super (props);
        this.state = {
            archive: []
        }
    }

    componentDidMount() {
        fetch("https://localhost:5001/api/archive")
        .then(response => response.json())
        .then((data) => this.setState(
            { archive: data}
        ));
    }

    render() {
        const ArticleComponent = this.state.archive.map((article, i) =>
            <ArticleBlock key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.summary}/>
        );
  
        return ( 
            <div> 
                {ArticleComponent}
                <p>{this.state.archive.length} articles in total.</p> 
                <Link to = "/">
                    <p> Return to Homepage </p> 
                </Link> 
            </div>
        );
    }
}

export default Archive