import React from 'react';
import './css/App.css';
import Article from './components/article';
import { Link } from 'react-router-dom';

class Home extends React.Component {
  
  state = {
    articles: []
  }

  componentDidMount() {
    fetch("https://localhost:5001/api/articles")
    .then(response => response.json())
    .then((data) => this.setState({ articles: data }))
    .catch(
      error => console.log(error)
    )
  }

  render(){

    const ArticleComponent = this.state.articles.map((article, i) =>
      <Article key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.description}/>
    );

    return (
      <div className="container">
        <div className="content">
          {ArticleComponent}
          <Link to="/Archive">
            <p>Article Archive</p>
          </Link>
        </div>
      </div>
    );
  }
}

export default Home;
