import React from 'react';
import {Link} from 'react-router-dom';
import logo from '../logo.png';

class Header extends React.Component {
    render() {
      return (
        <div className="header">
          <Link to='/'><img src={logo} className="App-logo" alt="logo" /></Link>
        </div>
      )
    }
  }

  export default Header;