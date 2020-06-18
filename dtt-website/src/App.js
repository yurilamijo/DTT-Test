import React from 'react';
import Footer from './components/footer';
import Header from './components/header';
import Home from './components/home';
import Archive from './components/archive';
import Admin from './components/admin';
import Article from './components/article/articleDetails';
import ArticleForm from './components/article/articleForm';
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