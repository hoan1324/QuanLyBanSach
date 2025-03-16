import axiosClient from "../axiosClient"

const permissionService = {
    url: `/Permission`,
    getPermissions() {
        return axiosClient.get(this.url);
    },
    getUserPermission(id) {
        return axiosClient.get(`${this.url}/user/${id}`);
    },
    getPositionPermission(id) {
        return axiosClient.get(`${this.url}/group/${id}`);
    },
    updatePositionPermission(id, request) {
        return axiosClient.put(`${this.url}/group/${id}`, request);
    },
    updateUserPermission(id, request) {
        return axiosClient.put(`${this.url}/user/${id}`, request);
    }

}
export default permissionService