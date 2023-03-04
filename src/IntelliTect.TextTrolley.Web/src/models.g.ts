import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  applicationUserId: number | null
  name: string | null
  id: string | null
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


