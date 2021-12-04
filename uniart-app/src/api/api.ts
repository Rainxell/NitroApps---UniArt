import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = "https://uniartapi2.herokuapp.com/api/v1";

const responseBody = <t>(response: AxiosResponse<t>) => response.data;
const request = {
    get: <t>(url: string) => axios.get<t>(url).then(responseBody),
    post: <t>(url: string, body: {}) => axios.post<t>(url, body).then(responseBody),
    put: <t>(url: string, body: {}) => axios.put<t>(url, body).then(responseBody),
    delete: <t>(url: string) => axios.delete<t>(url).then(responseBody),
};

export default request;