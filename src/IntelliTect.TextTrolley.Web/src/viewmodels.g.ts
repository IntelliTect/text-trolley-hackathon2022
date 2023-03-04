import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  applicationUserId: number | null;
  name: string | null;
  id: string | null;
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
  ApplicationUser: ApplicationUserViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
  LoginService: LoginServiceViewModel,
}

