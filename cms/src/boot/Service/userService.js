import axiosClient from "../axiosClient"

const userService = {
    url: `/User`,
    getList(request) {
        return axiosClient.get(this.url, { params: request })
    },
    getById(id) {
        return axiosClient.get(`${this.url}/${id}`);
    },
    getToken(request) {
        return axiosClient.post(`${this.url}/get-token`, request);
    },
    create(request) {
        return axiosClient.post(`${this.url}`, request);
    },
    update(id, request) {
        return axiosClient.put(`${this.url}/${id}`, request);
    },
    delete(id) {
        return axiosClient.delete(`${this.url}/${id}`);
    },
    changePassword(payload) {
        return axiosClient.post(`${this.url}/change-password`, payload);
    },
    resetPassword(payload) {
        return axiosClient.post(`${this.url}/reset-password`, payload);
    }
}
export default userService