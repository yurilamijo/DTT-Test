import React from 'react';
import Footer from './components/Footer';
import Header from './components/Header';
import Home from './components/Home';
import Archive from './components/Archive';
import Admin from './components/Admin';
import Article from './components/article/ArticleDetails';
import ArticleForm from './components/article/ArticleForm';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import './css/App.css';

class App extends React.Component {
  
  render(){
    return (
      <Router>
          <div className="container">
            <Header/>
            <div className="content">
              <Switch>
                <Route path='/' exact component={Home}/>
                <Route path='/article/:id' component={Article}/>
                <Route path='/archive' component={Archive}/>
                <Route path='/admin' exact component={Admin}/>
                <Route path='/admin/edit-article/:id' component={ArticleForm}/>
                <Route path='/admin/add-article' component={ArticleForm}/>
              </Switch>
            </div>
            <Footer/>
          </div>
      </Router>
    );
  }
}

export default App;