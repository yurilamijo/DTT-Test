import { getToken } from './Helper';

export const AuthHeader = {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${ getToken()}`
};
  
const url = 'https://localhost:5001';

export const APIPaths = {
    allArticles: `${url}/api/articles`,
    article: `${url}/api/article/`,
    archive: `${url}/api/archive/`,
    login: `${url}/api/auth/`
};