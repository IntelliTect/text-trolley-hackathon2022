import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationRole extends Model<typeof metadata.ApplicationRole> {
  id: number | null
  name: string | null
  normalizedName: string | null
  concurrencyStamp: string | null
}
export class ApplicationRole {
  
  /** Mutates the input object and its descendents into a valid ApplicationRole implementation. */
  static convert(data?: Partial<ApplicationRole>): ApplicationRole {
    return convertToModel(data || {}, metadata.ApplicationRole) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationRole implementation. */
  static map(data?: Partial<ApplicationRole>): ApplicationRole {
    return mapToModel(data || {}, metadata.ApplicationRole) 
  }
  
  /** Instantiate a new ApplicationRole, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationRole> | {[k: string]: any}) {
      Object.assign(this, ApplicationRole.map(data || {}));
  }
}


export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  name: string | null
  id: number | null
  userName: string | null
  normalizedUserName: string | null
  email: string | null
  normalizedEmail: string | null
  emailConfirmed: boolean | null
  passwordHash: string | null
  securityStamp: string | null
  concurrencyStamp: string | null
  phoneNumber: string | null
  phoneNumberConfirmed: boolean | null
  twoFactorEnabled: boolean | null
  lockoutEnd: Date | null
  lockoutEnabled: boolean | null
  accessFailedCount: number | null
}
export class ApplicationUser {
  
  /** Mutates the input object and its descendents into a valid ApplicationUser implementation. */
  static convert(data?: Partial<ApplicationUser>): ApplicationUser {
    return convertToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationUser implementation. */
  static map(data?: Partial<ApplicationUser>): ApplicationUser {
    return mapToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Instantiate a new ApplicationUser, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationUser> | {[k: string]: any}) {
      Object.assign(this, ApplicationUser.map(data || {}));
  }
}


export interface Requester extends Model<typeof metadata.Requester> {
  requesterId: number | null
  requesterName: string | null
  requesterNumber: string | null
  activeShoppingListKey: number | null
  activeShoppingList: ShoppingList | null
}
export class Requester {
  
  /** Mutates the input object and its descendents into a valid Requester implementation. */
  static convert(data?: Partial<Requester>): Requester {
    return convertToModel(data || {}, metadata.Requester) 
  }
  
  /** Maps the input object and its descendents to a new, valid Requester implementation. */
  static map(data?: Partial<Requester>): Requester {
    return mapToModel(data || {}, metadata.Requester) 
  }
  
  /** Instantiate a new Requester, optionally basing it on the given data. */
  constructor(data?: Partial<Requester> | {[k: string]: any}) {
      Object.assign(this, Requester.map(data || {}));
  }
}


export interface ShoppingList extends Model<typeof metadata.ShoppingList> {
  shoppingListId: number | null
  requester: Requester | null
  applicationUsers: ApplicationUser[] | null
  items: ShoppingListItem[] | null
  isComplete: boolean | null
  isDelivered: boolean | null
}
export class ShoppingList {
  
  /** Mutates the input object and its descendents into a valid ShoppingList implementation. */
  static convert(data?: Partial<ShoppingList>): ShoppingList {
    return convertToModel(data || {}, metadata.ShoppingList) 
  }
  
  /** Maps the input object and its descendents to a new, valid ShoppingList implementation. */
  static map(data?: Partial<ShoppingList>): ShoppingList {
    return mapToModel(data || {}, metadata.ShoppingList) 
  }
  
  /** Instantiate a new ShoppingList, optionally basing it on the given data. */
  constructor(data?: Partial<ShoppingList> | {[k: string]: any}) {
      Object.assign(this, ShoppingList.map(data || {}));
  }
}


export interface ShoppingListItem extends Model<typeof metadata.ShoppingListItem> {
  shoppingListItemId: number | null
  name: string | null
  originalName: string | null
  shoppingListId: number | null
  shoppingList: ShoppingList | null
  purchased: boolean | null
}
export class ShoppingListItem {
  
  /** Mutates the input object and its descendents into a valid ShoppingListItem implementation. */
  static convert(data?: Partial<ShoppingListItem>): ShoppingListItem {
    return convertToModel(data || {}, metadata.ShoppingListItem) 
  }
  
  /** Maps the input object and its descendents to a new, valid ShoppingListItem implementation. */
  static map(data?: Partial<ShoppingListItem>): ShoppingListItem {
    return mapToModel(data || {}, metadata.ShoppingListItem) 
  }
  
  /** Instantiate a new ShoppingListItem, optionally basing it on the given data. */
  constructor(data?: Partial<ShoppingListItem> | {[k: string]: any}) {
      Object.assign(this, ShoppingListItem.map(data || {}));
  }
}


