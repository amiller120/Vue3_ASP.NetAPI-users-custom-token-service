import axios, { AxiosRequestConfig } from "axios";
import { ApiResponse } from "./Models/ApiResponse";

export default class ApiServiceBase {
    private base_url = "/api";
    protected RESOURCE_NAME: string;

    constructor(resource_name: string) {
        this.RESOURCE_NAME = resource_name;
    }


    public async Get<T>(url: string, params: any | undefined | null) // the url should include the query string on any get call, so I don't include a body in the params
    {
        let getRequestConfig = {
            url: `${this.base_url}/${this.RESOURCE_NAME}${url}`,
            method: 'get',
            params: params
        } as AxiosRequestConfig<T>

        return await this.Request<T>(getRequestConfig);
    }

    async Request<T>(requestConfig: AxiosRequestConfig<T>) {
        return axios.request<ApiResponse<T>>(requestConfig).then(res => {
            return {
                data: res.data,
                status: res.status
            } as ApiResponse<T>
        }).catch();
    }
}