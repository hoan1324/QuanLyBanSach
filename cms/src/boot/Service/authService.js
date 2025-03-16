import axiosClient from "../axiosClient"

const authService = {
    url: `/Auth`,
    login(request) {
        return axiosClient.post(`${this.url}/login`, request);
    },
    getCurrentUser() {
        return axiosClient.get(`${this.url}/current-user`);
    },
    logOut() {
        return axiosClient.post(`${this.url}/logout`);
    },
    refreshToken(accessToken) {
        return axiosClient.post(`${this.url}/refresh-token`, { accessToken: accessToken });
    },
}
export default authService