<script setup lang="ts">
interface ButtonProps {
  p?: string
}

const props = withDefaults(defineProps<ButtonProps>(), {
  p: 'p-3',
})
</script>

<template>
  <button
    :class="[
      'bg-primary font-russo leading-none h-auto m-0 align-middle text-xl shadow-md text-shadow text-white rounded transition duration-150 filter hover:brightness-110 active:brightness-125', props.p]"
    >
    <slot></slot>
  </button>
</template>