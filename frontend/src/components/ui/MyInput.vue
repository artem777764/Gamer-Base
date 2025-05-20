<script setup lang="ts">
defineProps({
  modelValue: String,
  placeholder: String,
  isPassword: {
    type: Boolean,
    default: false,
  }
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()
</script>

<template>
  <input :value="modelValue"
  @input="(e) => emit('update:modelValue', (e.target as HTMLInputElement).value)"
  :type="isPassword ? 'password' : 'text'"
  :placeholder="placeholder"
  class="font-russo rounded text-xl bg-background text-white p-3 transition duration-150 focus:outline-none focus:brightness-110">
</template>