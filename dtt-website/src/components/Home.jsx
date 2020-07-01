import React from 'react';
import ArticleBlock from './article/ArticleBlock';
import {Link} from 'react-router-dom';
import '../css/Article.css';

class Home extends React.Component {
  constructor(props) {
    super (props);
    this.state = {
        articles: []
    }
  }

  componentDidMount() {
    // Calls the API to get the 5 recents articles
    fetch("https://localhost:5001/api/articles")
      .then(response => response.json())
      .then((data) => this.setState(
        { articles: data }
      ))
      .catch(
        error => console.log(error)
      )
  }

  render() {
    // Loops through the list of articles and sends that data to ArticleBlok
    // Stores a list of articles that will be showed
    const ArticleComponent = this.state.articles.map((article, i) =>
      <ArticleBlock key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.summary}/>
    );

    return ( 
      <div> 
        {ArticleComponent} 
        <Link to = "/archive">
          <p> Article Archive </p> 
        </Link> 
      </div>
    );
  }
}

export default Home;
