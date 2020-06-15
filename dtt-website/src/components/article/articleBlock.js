import React from 'react';
import { Link } from 'react-router-dom';

class ArticleBlock extends React.Component {
    render() {
        const { id, date, title, desc } = this.props;

        const dateTimeFormat = new Intl.DateTimeFormat('en', { year: 'numeric', month: 'long', day: '2-digit' }); 
        const [{value:month},, {value:day}] = dateTimeFormat.formatToParts(new Date(date));

        return (
            <div className="article" id={id}>
                <div className="article-left">
                    <p className="publishdate">{day} {month}</p>
                </div>
                <div className="article-right">
                    <h3 className="article-title"><Link to={`/article/${id}`}>{title}</Link></h3>
                    <p>{desc}</p>
                </div>
            </div>
        );
    }
}

export default ArticleBlock;