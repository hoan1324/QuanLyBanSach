import axiosClient from "../axiosClient"

export default {
    url: `/AttachmentFolder`,
    getFileInFolder(request){
        return axiosClient.get(`${this.url}/files`, {params: request})
    },
    create(request){
        return axiosClient.post(`${this.url}`, request);
    },
    update(id, request){
        return axiosClient.put(`${this.url}/${id}`, request);
    },
    delete(id){
        return axiosClient.delete(`${this.url}/${id}`);
    }
    
}