import React from 'react';
import { formatDate } from '../../Helper';
import { Link, useRouteMatch } from 'react-router-dom';

export function PreviewArticles(props) {
    let {url} = useRouteMatch();

    const articlesRows = props.articles.map((article, i) =>
        <tr key={article.id}>
            <td>{formatDate(article.publishDate,'numeric','short','2-digit',false)}</td>
            <Link to={`${url}/edit-article/${article.id}`}>
                <td>{article.title}</td>
            </Link>
        </tr>
    );

    return (
        <tbody>
            {articlesRows}
        </tbody>
    );
}
