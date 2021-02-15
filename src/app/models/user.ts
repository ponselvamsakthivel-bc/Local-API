export interface User {
    id: number,
    firstName: string;
    lastName: string;
    userName: string;
    userGroups: UserGroup[]
}

export interface UserGroup {
    group: string;
    role: string;
}