import React from "react";
import '../css/NewsWidget.css';

class NewsWidget extends React.Component {
  constructor(props) {
    super(props);

    this.logout = this.logout.bind(this);
  }

  logout() {
    localStorage.removeItem('user');
  }

  render() {
    const role = JSON.parse(localStorage.getItem('user')).role;

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