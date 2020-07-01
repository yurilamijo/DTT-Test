import React from "react";
import { getUserRole } from '../Helper';
import '../css/NewsWidget.css';

class NewsWidget extends React.Component {
  constructor(props) {
    super(props);

    this.logout = this.logout.bind(this);
  }

  logout() {
    // Removes the user from the localstorage
    localStorage.removeItem('user');
  }

  render() {
    const role = getUserRole();

    return (
      <div className="news-widget">
        <h3>Widget News {role}</h3>
        <div className="news">
            <p>You are logged in as {role}.</p>
            <a onClick={this.logout} href="/">Log out</a>
        </div>
      </div>
    );
  }
}

export default NewsWidget;