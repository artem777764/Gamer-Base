<script setup lang="ts">
defineProps({
  modelValue: String,
  placeholder: String,
  fontSize: {
    type: String,
    default: "text-xl",
  },
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
  (e: 'submit'): void
}>()

const handleSubmit = (e: Event) => {
  e.preventDefault()
  emit('submit')
}

</script>

<template>
    <div class="px-5 pt-5">
        <form @submit="handleSubmit" class="w-full">
          <MyInput
            :modelValue="modelValue"
            :fontSize="fontSize"
            @update:modelValue="(value: string) => emit('update:modelValue', value)"
            @keydown.enter="emit('submit')"
            background-color="bg-secondary"
            :placeholder="placeholder"
            class="w-full"/>
        </form>
    </div>
</template>