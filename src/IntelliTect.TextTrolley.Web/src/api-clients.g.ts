import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class RequesterApiClient extends ModelApiClient<$models.Requester> {
  constructor() { super($metadata.Requester) }
}


export class ShoppingListApiClient extends ModelApiClient<$models.ShoppingList> {
  constructor() { super($metadata.ShoppingList) }
}


export class ShoppingListItemApiClient extends ModelApiClient<$models.ShoppingListItem> {
  constructor() { super($metadata.ShoppingListItem) }
}


