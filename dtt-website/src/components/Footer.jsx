import React from 'react';
import {Link} from 'react-router-dom';

class Footer extends React.Component {
    render() {
      return (
        <div className="footer">
          <p>DTT Multiemedia 2015. All rights reserved. <Link to="/admin">Site Admin</Link></p>
        </div>
      )
    }
}

export default Footer;
