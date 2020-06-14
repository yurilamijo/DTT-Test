import React from 'react';
import logo from './logo.png';
import './css/App.css';
import Home from './home';
import Archive from './archive';
import Admin from './admin';
import Info from './info';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';

class App extends React.Component {
  
  // state = {
  //   articles: []
  // }

  // componentDidMount() {
  //   fetch("https://localhost:5001/api/articles")
  //   .then(response => response.json())
  //   .then((data) => this.setState({ articles: data }))
  //   .catch(
  //     error => console.log(error)
  //   )
  // }

  render(){

    // const ArticleComponent = this.state.articles.map((article, i) =>
    //   <Article key={i} id={article.id} date={article.publishDate} title={article.title} desc={article.description}/>
    // );

    return (
      // <div className="container">
        // <div className="header">
        //   <img src={logo} className="App-logo" alt="logo" />
        // </div>
      //   <div className="content">
      //     {ArticleComponent}
      //     <a href="#">Article Archive</a>
      //   </div>
        // <div className="footer">
        //   <p>DTT Multiemedia 2015. All rights reserved. <a href="admin">Site Admin</a></p>
        // </div>
      // </div>
      <Router>
          <div className="header">
            <img src={logo} className="App-logo" alt="logo" />
          </div>
          <Switch>
            <Route path='/' component={Home}/>
            <Route path='/Info' component={Info}/>
            <Route path='/Archive' component={Archive}/>
            <Route path='/Admin' component={Admin}/>
          </Switch>
          <div className="footer">
            <p>DTT Multiemedia 2015. All rights reserved. <a href="admin">Site Admin</a></p>
          </div>
      </Router>
    );
  }
}

export default App;
