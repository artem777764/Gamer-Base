<script setup lang="ts">
import { computed } from 'vue';
const props = defineProps({
  modelValue: String,
  placeholder: String,
  isPassword: {
    type: Boolean,
    default: false,
  },
  fontSize: {
    type: String,
    default: "text-xl",
  },
  backgroundColor: {
    type: String,
    default: "bg-background",
  },
  multiline: {
    type: Boolean,
    default: false,
  },
})

const inputClass = computed(() => {
  return [
    'font-russo rounded text-white p-3 shadow-md transition duration-150 focus:outline-none focus:brightness-110',
    props.fontSize,
    props.backgroundColor
  ]
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()
</script>

<template>
  <textarea
    v-if="multiline"
    :value="modelValue"
    @input="(e) => emit('update:modelValue', (e.target as HTMLTextAreaElement).value)"
    :placeholder="placeholder"
    :class="inputClass"
    rows="4"
  />

  <input
    v-else
    :value="modelValue"
    @input="(e) => emit('update:modelValue', (e.target as HTMLInputElement).value)"
    :type="isPassword ? 'password' : 'text'"
    :placeholder="placeholder"
    :class="inputClass"
  />
</template>