import React from 'react'

class Article extends React.Component {
    render() {
        const { id, date, title, desc } = this.props

        const dateTimeFormat = new Intl.DateTimeFormat('en', { year: 'numeric', month: 'long', day: '2-digit' }) 
        const [{value:month},, {value:day}] = dateTimeFormat.formatToParts(new Date(date))

        return (
            <div className="article" id={id}>
                <div className="article-left">
                    <p className="publish-date">{day} {month}</p>
                </div>
                <div className="article-right">
                    <h3 className="article-title"><a href="info">{title}</a></h3>
                    <p>{desc}</p>
                </div>
            </div>
        );
    }
}

export default Article;