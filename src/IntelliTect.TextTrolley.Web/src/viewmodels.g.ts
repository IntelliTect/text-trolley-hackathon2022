import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationRoleViewModel extends $models.ApplicationRole {
  id: number | null;
  name: string | null;
  normalizedName: string | null;
  concurrencyStamp: string | null;
}
export class ApplicationRoleViewModel extends ViewModel<$models.ApplicationRole, $apiClients.ApplicationRoleApiClient, number> implements $models.ApplicationRole  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationRole> | null) {
    super($metadata.ApplicationRole, new $apiClients.ApplicationRoleApiClient(), initialData)
  }
}
defineProps(ApplicationRoleViewModel, $metadata.ApplicationRole)

export class ApplicationRoleListViewModel extends ListViewModel<$models.ApplicationRole, $apiClients.ApplicationRoleApiClient, ApplicationRoleViewModel> {
  
  constructor() {
    super($metadata.ApplicationRole, new $apiClients.ApplicationRoleApiClient())
  }
}


export interface ApplicationUserViewModel extends $models.ApplicationUser {
  name: string | null;
  id: number | null;
  userName: string | null;
  normalizedUserName: string | null;
  email: string | null;
  normalizedEmail: string | null;
  emailConfirmed: boolean | null;
  passwordHash: string | null;
  securityStamp: string | null;
  concurrencyStamp: string | null;
  phoneNumber: string | null;
  phoneNumberConfirmed: boolean | null;
  twoFactorEnabled: boolean | null;
  lockoutEnd: Date | null;
  lockoutEnabled: boolean | null;
  accessFailedCount: number | null;
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
  
  
  public addToItems() {
    return this.$addChild('items') as ShoppingListItemViewModel
  }
  
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
  shoppingListId: number | null;
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


export class LoginServiceViewModel extends ServiceViewModel<typeof $metadata.LoginService, $apiClients.LoginServiceApiClient> {
  
  public get loginUser() {
    const loginUser = this.$apiClient.$makeCaller(
      this.$metadata.methods.loginUser,
      (c, email: string | null, password: string | null) => c.loginUser(email, password),
      () => ({email: null as string | null, password: null as string | null, }),
      (c, args) => c.loginUser(args.email, args.password))
    
    Object.defineProperty(this, 'loginUser', {value: loginUser});
    return loginUser
  }
  
  public get registerUser() {
    const registerUser = this.$apiClient.$makeCaller(
      this.$metadata.methods.registerUser,
      (c, firstName: string | null, lastName: string | null, email: string | null, password: string | null, phoneNumber: string | null) => c.registerUser(firstName, lastName, email, password, phoneNumber),
      () => ({firstName: null as string | null, lastName: null as string | null, email: null as string | null, password: null as string | null, phoneNumber: null as string | null, }),
      (c, args) => c.registerUser(args.firstName, args.lastName, args.email, args.password, args.phoneNumber))
    
    Object.defineProperty(this, 'registerUser', {value: registerUser});
    return registerUser
  }
  
  constructor() {
    super($metadata.LoginService, new $apiClients.LoginServiceApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationRole: ApplicationRoleViewModel,
  ApplicationUser: ApplicationUserViewModel,
  Requester: RequesterViewModel,
  ShoppingList: ShoppingListViewModel,
  ShoppingListItem: ShoppingListItemViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationRole: ApplicationRoleListViewModel,
  ApplicationUser: ApplicationUserListViewModel,
  Requester: RequesterListViewModel,
  ShoppingList: ShoppingListListViewModel,
  ShoppingListItem: ShoppingListItemListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  LoginService: LoginServiceViewModel,
}

