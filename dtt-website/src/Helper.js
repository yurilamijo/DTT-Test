// Formates the given date
function formatDate(date, typeYear, typeMonth, typeDay, seperator) {
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat
    const dateFormat = new Intl.DateTimeFormat('en', { year: typeYear, month: typeMonth, day: typeDay }) 
    const [{ value: month },,{ value: day },,{ value: year }] = dateFormat.formatToParts(new Date(date)) 
    const formatedDate = seperator ? `${year}-${month}-${day}` : `${day} ${month} ${year}`;
    return formatedDate;
}

// Returns the JWT token
function getToken() {
    let token;
    if (localStorage.getItem('user')) {
        token = JSON.parse(localStorage.getItem('user')).token;
    }
    return token;
}

// Decodes the JWT token
function decodeToken() {
    const jwt_decode = require('jwt-decode');
    const token = getToken();
    const decoded = jwt_decode(token);
    return decoded;
}

// Checks if the user is authenticated
function isAuthenticated() {
    if (!localStorage.getItem('user')) return false;

    const token = decodeToken();
    // Checks if the token is expired
    if (token.exp < Date.now() / 1000) {
        localStorage.removeItem('user')
        return false;
    }
    return true;
}

// Returns the users role
function getUserRole() {
    const token = decodeToken();
    return token.role;
}

export {
    formatDate,
    getToken,
    isAuthenticated,
    getUserRole
}