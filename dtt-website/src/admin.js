import React from 'react';
import {Link} from 'react-router-dom';

class Admin extends React.Component {
    constructor(props) {
        super (props);
        this.state = {articles: []};
    }
    
    componentDidMount() {
        fetch("https://localhost:5001/api/articles")
          .then(response => response.json())
          .then((data) => this.setState(
            { articles: data }
          ))
          .catch(
            error => console.log(error)
          )
      }

    render(){
        const previewArticles = this.state.articles.map((article, i) =>
                <tr key={article.id}>
                    <td>{article.publishDate}</td>
                    <Link to={`edit-article/${article.id}`}>
                        <td>{article.title}</td>
                    </Link>
                </tr>
        );

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
                    <tbody>
                        {previewArticles}
                    </tbody>
                </table>
                <p>{this.state.articles.length} articles in total.</p> 
                <Link to = "/add-article">
                    <p> Add Article </p> 
                </Link> 
            </div>
        )
    }
}

export default Admin