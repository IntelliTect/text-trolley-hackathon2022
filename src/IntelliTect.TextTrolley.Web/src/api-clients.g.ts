import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class LoginServiceApiClient extends ServiceApiClient<typeof $metadata.LoginService> {
  constructor() { super($metadata.LoginService) }
  public loginUser(email: string | null, password: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.loginUser
    const $params =  {
      email,
      password,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public registerUser(firstName: string | null, lastName: string | null, email: string | null, password: string | null, phoneNumber: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.registerUser
    const $params =  {
      firstName,
      lastName,
      email,
      password,
      phoneNumber,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


