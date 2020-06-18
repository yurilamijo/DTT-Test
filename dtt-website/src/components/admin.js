import React from 'react';
import {Link, useRouteMatch} from 'react-router-dom';
import '../css/admin.css'
class Admin extends React.Component {
    constructor(props) {
        super (props);
        this.state = {articles: []};
    }
    
    componentDidMount() {
        // Calls the API to get the all the articles
        fetch("https://localhost:5001/api/archive")
          .then(response => response.json())
          .then((data) => this.setState(
            { articles: data }
          ))
          .catch(
            error => console.log(error)
          )
      }

    render(){
        return (
            <div>
                <h1>Admin - All articles</h1>
                <table className="articles-overview">
                    <thead>
                        <tr>
                            <th>Publication Date</th>
                            <th>Article</th>
                        </tr>
                    </thead>
                    <PreviewArticles articles={this.state.articles}/>
                </table>
                <p>{this.state.articles.length} articles in total.</p> 
                <AddArticleLink />
            </div>
        )
    }
}

export default Admin

function PreviewArticles(props) {
    let {url} = useRouteMatch();

    const articlesRows = props.articles.map((article, i) =>
            <tr key={article.id}>
                <td>{article.publishDate}</td>
                <Link to={`${url}/edit-article/${article.id}`}>
                    <td>{article.title}</td>
                </Link>
            </tr>
    );

    return (
        <tbody>
            {articlesRows}
        </tbody>
    );
}

function AddArticleLink() {
    let {url} = useRouteMatch();

    return (
        <Link to={`${url}/add-article`}>
            <p> Add Article </p> 
        </Link> 
    );
}