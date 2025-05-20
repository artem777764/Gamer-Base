import type { App } from 'vue'

export default function registerGlobalComponents(app: App) {
  const components = import.meta.glob('../components/ui/**/*.vue', { eager: true })

  Object.entries(components).forEach(([path, definition]: any) => {
    const component = definition.default
    const name = component.name || path.split('/').pop()?.replace('.vue', '')
    if (name) {
      app.component(name, component)
    }
  })
}
