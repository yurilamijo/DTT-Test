function FormatDate(date, typeYear, typeMonth, typeDay, seperator) {
    const dateFormat = new Intl.DateTimeFormat('en', { year: typeYear, month: typeMonth, day: typeDay }) 
    const [{ value: month },,{ value: day },,{ value: year }] = dateFormat.formatToParts(new Date(date)) 
    const formatedDate = seperator ? `${year}-${month}-${day}` : `${day} ${month} ${year}`;

    return formatedDate;
}

export {
    FormatDate
}