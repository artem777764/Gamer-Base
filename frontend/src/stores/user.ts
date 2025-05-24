import { defineStore } from 'pinia'

export const useUserStore = defineStore('user', {
  state: () => ({
    id: null as number | null,
    roleId: null as number | null,
  }),
  actions: {
    setUser(id: number, roleId: number) {
      this.id = id
      this.roleId = roleId
    },
    logout() {
      this.id = null
      this.roleId = null
    }
  },
  persist: true,
})
