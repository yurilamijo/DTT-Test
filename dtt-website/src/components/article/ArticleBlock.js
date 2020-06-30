import React from 'react';
import { Link } from 'react-router-dom';
import { formatDate } from '../Helper';


class ArticleBlock extends React.Component {
    render() {
        // Gets the parameters/props that where send by the Home component
        const { id, date, title, desc } = this.props;
        // Formats the date
        const publishDate = formatDate(date,'numeric','long','2-digit', false)

        return (
            <div className="article" id={id}>
                <div className="article-left">
                    <p className="publishdate">{publishDate}</p>
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
