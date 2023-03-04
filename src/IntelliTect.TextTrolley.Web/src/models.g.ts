import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  applicationUserId: number | null
  name: string | null
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
  requesterId: string | null
  applicationUserIds: number[] | null
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
  shoppingListId: number | null
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


