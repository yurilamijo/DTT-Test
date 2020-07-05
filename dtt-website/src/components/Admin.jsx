import React from 'react';
import { Link, useRouteMatch } from 'react-router-dom';
import { PreviewArticles } from './article/ArticlePreview';
import NewsWidget from './NewsWidget';
import { getUserRole } from '../Helper';
import { APIPaths } from '../Constants';
import '../css/Admin.css'
class Admin extends React.Component {
    constructor(props) {
        super (props);
        this.state = {articles: []};
    }
    
    componentDidMount() {
        // Calls the API to get the all the articles
        fetch(APIPaths.archive)
          .then(response => response.json())
          .then((data) => this.setState(
            { articles: data }
          ))
          .catch(
            error => console.log(error)
          )
      }

    render(){
        // Shows the link if authorized
        const ConditionalLink = getUserRole() == "Admin" ? AddArticleLink : 'div';

        return (
            <div>
                <NewsWidget/>
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
                <ConditionalLink />
            </div>
        )
    }
}

export default Admin

function AddArticleLink() {
    let {url} = useRouteMatch();

    return (
        <Link to={`${url}/add-article`}>
            <p> Add Article </p> 
        </Link> 
    );
}
