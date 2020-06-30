import React from 'react';
import { formatDate, getUserRole } from '../Helper';
import { Link, useRouteMatch } from 'react-router-dom';

export function PreviewArticles(props) {
    let {url} = useRouteMatch();
    const ConditionalLink = getUserRole() == "Admin" ? Link : 'div';

    const articlesRows = props.articles.map((article, i) =>
        <tr key={article.id}>
            <td>{formatDate(article.publishDate,'numeric','short','2-digit',false)}</td>
            <ConditionalLink to={`${url}/edit-article/${article.id}`}>
                <td>{article.title}</td>
            </ConditionalLink>
        </tr>
    );

    return (
        <tbody>
            {articlesRows}
        </tbody>
    );
}
