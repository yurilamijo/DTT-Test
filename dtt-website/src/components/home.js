import React from 'react';
import ArticleBlock from './article/articleBlock';
import {Link} from 'react-router-dom';
import '../css/article.css';

class Home extends React.Component {
  constructor(props) {
    super (props);
    this.state = {
        articles: []
    }
  }

  componentDidMount() {
    fetch("https://localhost:5001/api/home/articles")
      .then(response => response.json())
      .then((data) => this.setState(
        { articles: data }
      ))
      .catch(
        error => console.log(error)
      )
  }

  render() {
    const ArticleComponent = this.state.articles.map((article, i) =>
      <ArticleBlock key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.description}/>
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