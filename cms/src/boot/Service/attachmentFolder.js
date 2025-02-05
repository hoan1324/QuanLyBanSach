import axiosClient from "../axiosClient"

export default {
    url: `/AttachmentFolder`,
    getFileInFolder(request) {
        return axiosClient.get(`${this.url}/files`, { params: request })
    },
    getListDropdown() {
        return axiosClient.get(`${this.url}/dropdown`)
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
    uploadFile(id,formData) {
        return axiosClient.put(`${this.url}/${id}/file`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
        });
    },
    uploadFiles(id,formData) {
        return axiosClient.put(`${this.url}/${id}/files`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
            
        });
    }

}