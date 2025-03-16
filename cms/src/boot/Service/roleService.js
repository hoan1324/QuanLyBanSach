import axiosClient from "../axiosClient"

const roleService = {
    url: `/Role`,
    dropdown() {
        return axiosClient.get(`${this.url}/dropdown`)
    },
    getList(request) {
        return axiosClient.get(this.url, { params: request })
    },
    getById(id) {
        return axiosClient.get(`${this.url}/${id}`);
    },
    create(request) {
        return axiosClient.post(`${this.url}`, request);
    },
    update(id, request) {
        return axiosClient.put(`${this.url}/${id}`, request);
    },
    delete(id) {
        return axiosClient.delete(`${this.url}/${id}`);
    }
}
export default roleService