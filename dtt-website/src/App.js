import React from 'react';
import logo from './logo.png';
import './css/App.css';
import Home from './home';
import Archive from './archive';
import Admin from './admin';
import Info from './info';
import ArticleForm from './components/articleForm';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';

class App extends React.Component {
  
  render(){
    return (

      <Router>
          <div className="container">
            <div className="header">
              <a href='/'><img src={logo} className="App-logo" alt="logo" /></a>
            </div>
            <div className="content">
            <Switch>
              <Route path='/' exact component={Home}/>
              <Route path='/article/:id' component={Info}/>
              <Route path='/archive' component={Archive}/>
              <Route path='/admin' component={Admin}/>
              <Route path='/edit-article/:id' component={ArticleForm}/>
              <Route path='/add-article' component={ArticleForm}/>
            </Switch>
            </div>
            <div className="footer">
              <p>DTT Multiemedia 2015. All rights reserved. <a href="admin">Site Admin</a></p>
            </div>
          </div>
      </Router>
    );
  }
}

export default App;
