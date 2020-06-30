function FormatDate(date, typeYear, typeMonth, typeDay, seperator) {
    const dateFormat = new Intl.DateTimeFormat('en', { year: typeYear, month: typeMonth, day: typeDay }) 
    const [{ value: month },,{ value: day },,{ value: year }] = dateFormat.formatToParts(new Date(date)) 
    const formatedDate = seperator ? `${year}-${month}-${day}` : `${day} ${month} ${year}`;

    return formatedDate;
}

// function AuthHeader() {
//     const user = JSON.parse(localStorage.getItem('user'));

//     if (user & user.token) {
//         return {'Authorization': 'Bearer ' + user.token}
//     }
//     return {};
// }

export {
    FormatDate
}