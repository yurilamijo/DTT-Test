import React from 'react';
import Article from './components/article';
import { Link } from 'react-router-dom';

class Archive extends React.Component {

    state = {
        archive: []
    }

    componentDidMount() {
        fetch("https://localhost:5001/api/archived")
        .then(response => response.json())
        .then((data) => this.setState(
            { archive: data}
        ));
    }

    render() {
        const ArticleComponent = this.state.archive.map((article, i) =>
            <Article key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.description}/>
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