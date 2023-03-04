import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  applicationUserId: number | null;
  name: string | null;
}
export class ApplicationUserViewModel extends ViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, number> implements $models.ApplicationUser  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationUser> | null) {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient(), initialData)
  }
}
defineProps(ApplicationUserViewModel, $metadata.ApplicationUser)

export class ApplicationUserListViewModel extends ListViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, ApplicationUserViewModel> {
  
  constructor() {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient())
  }
}


export interface RequesterViewModel extends $models.Requester {
  requesterId: number | null;
  requesterName: string | null;
  requesterNumber: string | null;
  activeShoppingListKey: number | null;
  activeShoppingList: ShoppingListViewModel | null;
}
export class RequesterViewModel extends ViewModel<$models.Requester, $apiClients.RequesterApiClient, number> implements $models.Requester  {
  
  constructor(initialData?: DeepPartial<$models.Requester> | null) {
    super($metadata.Requester, new $apiClients.RequesterApiClient(), initialData)
  }
}
defineProps(RequesterViewModel, $metadata.Requester)

export class RequesterListViewModel extends ListViewModel<$models.Requester, $apiClients.RequesterApiClient, RequesterViewModel> {
  
  constructor() {
    super($metadata.Requester, new $apiClients.RequesterApiClient())
  }
}


export interface ShoppingListViewModel extends $models.ShoppingList {
  shoppingListId: number | null;
  requester: RequesterViewModel | null;
  applicationUsers: ApplicationUserViewModel[] | null;
  items: ShoppingListItemViewModel[] | null;
  isComplete: boolean | null;
  isDelivered: boolean | null;
}
export class ShoppingListViewModel extends ViewModel<$models.ShoppingList, $apiClients.ShoppingListApiClient, number> implements $models.ShoppingList  {
  
  constructor(initialData?: DeepPartial<$models.ShoppingList> | null) {
    super($metadata.ShoppingList, new $apiClients.ShoppingListApiClient(), initialData)
  }
}
defineProps(ShoppingListViewModel, $metadata.ShoppingList)

export class ShoppingListListViewModel extends ListViewModel<$models.ShoppingList, $apiClients.ShoppingListApiClient, ShoppingListViewModel> {
  
  constructor() {
    super($metadata.ShoppingList, new $apiClients.ShoppingListApiClient())
  }
}


export interface ShoppingListItemViewModel extends $models.ShoppingListItem {
  shoppingListItemId: number | null;
  name: string | null;
  originalName: string | null;
  shoppingList: ShoppingListViewModel | null;
  purchased: boolean | null;
}
export class ShoppingListItemViewModel extends ViewModel<$models.ShoppingListItem, $apiClients.ShoppingListItemApiClient, number> implements $models.ShoppingListItem  {
  
  constructor(initialData?: DeepPartial<$models.ShoppingListItem> | null) {
    super($metadata.ShoppingListItem, new $apiClients.ShoppingListItemApiClient(), initialData)
  }
}
defineProps(ShoppingListItemViewModel, $metadata.ShoppingListItem)

export class ShoppingListItemListViewModel extends ListViewModel<$models.ShoppingListItem, $apiClients.ShoppingListItemApiClient, ShoppingListItemViewModel> {
  
  constructor() {
    super($metadata.ShoppingListItem, new $apiClients.ShoppingListItemApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationUser: ApplicationUserViewModel,
  Requester: RequesterViewModel,
  ShoppingList: ShoppingListViewModel,
  ShoppingListItem: ShoppingListItemViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
  Requester: RequesterListViewModel,
  ShoppingList: ShoppingListListViewModel,
  ShoppingListItem: ShoppingListItemListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

